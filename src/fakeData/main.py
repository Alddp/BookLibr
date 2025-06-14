import os
import sys
import argparse

# 添加项目根目录到系统路径
current_dir = os.path.dirname(os.path.abspath(__file__))
sys.path.append(current_dir)

from src.data_generators.generators import (
    generate_bookshelves,
    generate_books,
    generate_users,
    generate_admins,
    generate_borrows,
)
from src.database.db_operations import insert_into_sqlserver
from src.utils.excel_utils import save_to_excel, import_from_excel
from src.utils.book_importer import import_books_from_file, validate_books

# 定义所有可用的表名
AVAILABLE_TABLES = {
    "bookshelf": "书架表",
    "book": "图书表",
    "user": "用户表",
    "admin": "管理员表",
    "borrow": "借阅记录表",
    "all": "所有表",
}


def parse_args(args=None):
    parser = argparse.ArgumentParser(description="图书管理系统数据生成和导入工具")

    # 添加子命令
    subparsers = parser.add_subparsers(dest="command", help="选择操作模式")

    # 生成数据命令
    generate_parser = subparsers.add_parser("generate", help="生成假数据")
    generate_parser.add_argument(
        "--table",
        type=str,
        choices=list(AVAILABLE_TABLES.keys()),
        default="all",
        help="指定要生成数据的表（默认：all）",
    )
    generate_parser.add_argument(
        "--count", type=int, default=10, help="生成数据的数量（默认：10）"
    )
    generate_parser.add_argument(
        "--output",
        type=str,
        default="library_data.xlsx",
        help="输出Excel文件名（默认：library_data.xlsx）",
    )
    generate_parser.add_argument(
        "--db", action="store_true", help="生成数据时同时插入数据库"
    )

    # 导入数据命令
    import_parser = subparsers.add_parser("import", help="从Excel导入数据")
    import_parser.add_argument(
        "--table",
        type=str,
        choices=list(AVAILABLE_TABLES.keys()),
        default="all",
        help="指定要导入数据的表（默认：all）",
    )
    import_parser.add_argument("--excel", type=str, required=True, help="Excel文件路径")
    import_parser.add_argument(
        "--db", action="store_true", help="导入数据时同时插入数据库"
    )

    return parser.parse_args(args)


def main(args=None):
    args = parse_args(args)

    # 数据库连接字符串
    conn_str = (
        "Driver={ODBC Driver 17 for SQL Server};"
        r"Server=.\SQLEXPRESS;"
        "Database=LibrBook;"
        "Trusted_Connection=yes;"
    )

    if args.command == "generate":
        # 生成数据
        data = {}

        if args.table == "all" or args.table == "bookshelf":
            data["Bookshelf"] = generate_bookshelves(args.count)

        if args.table == "all" or args.table == "book":
            shelves = data.get("Bookshelf", generate_bookshelves(args.count))
            data["Book"] = generate_books(shelves, args.count * 5)

        if args.table == "all" or args.table == "user":
            data["UserTable"] = generate_users(args.count)

        if args.table == "all" or args.table == "admin":
            data["Admin"] = generate_admins(args.count // 2)

        if args.table == "all" or args.table == "borrow":
            users = data.get("UserTable", generate_users(args.count))
            books = data.get(
                "Book", generate_books(generate_bookshelves(args.count), args.count * 5)
            )
            admins = data.get("Admin", generate_admins(args.count // 2))
            data["Borrow"] = generate_borrows(users, books, admins, args.count * 10)

        # 保存到Excel
        save_to_excel(data, args.output)
        print(f"数据已保存到Excel文件: {args.output}")

        # 根据参数决定是否插入数据库
        if args.db:
            insert_into_sqlserver(data, conn_str)
            print("数据已同时插入数据库")
        else:
            print("数据仅保存到Excel，未插入数据库")

    elif args.command == "import":
        if not args.excel:
            raise ValueError("import模式需要指定--excel参数")

        try:
            # 导入数据
            if args.table == "all":
                # 导入所有表
                import_from_excel(args.excel, conn_str if args.db else None)
            else:
                # 导入指定表
                data = import_from_excel(args.excel, None)  # 先不插入数据库

                # 不区分大小写查找表名
                found_table = None
                for key in data.keys():
                    if key.lower() == args.table.lower():
                        found_table = key
                        break

                if found_table:
                    if args.db:
                        # 只插入指定表的数据
                        table_data = {found_table: data[found_table]}
                        insert_into_sqlserver(table_data, conn_str)
                        print(f"{AVAILABLE_TABLES[args.table]}数据已导入数据库")
                    else:
                        print(f"{AVAILABLE_TABLES[args.table]}数据已从Excel读取")
                else:
                    print(f"Excel文件中未找到{AVAILABLE_TABLES[args.table]}的数据")

        except Exception as e:
            print(f"导入数据时发生错误: {str(e)}")

    else:
        parse_args(["--help"])


if __name__ == "__main__":
    main()

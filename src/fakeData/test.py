import os
import sys
import pandas as pd
from datetime import datetime
from main import main as run_main

# 添加项目根目录到系统路径
current_dir = os.path.dirname(os.path.abspath(__file__))
sys.path.append(current_dir)


def run_test(test_name, args):
    """运行测试命令并打印结果"""
    print(f"\n=== 测试 {test_name} ===")
    print(f"执行参数: {args}")

    try:
        # 保存原始参数
        original_argv = sys.argv.copy()

        # 设置新的命令行参数
        sys.argv = [sys.argv[0]] + args

        # 运行主函数
        run_main()

        # 恢复原始参数
        sys.argv = original_argv
        return True
    except Exception as e:
        print(f"执行出错: {str(e)}")
        # 恢复原始参数
        sys.argv = original_argv
        return False


def check_excel_file(file_path, expected_tables=None):
    """检查Excel文件是否正确生成"""
    if not os.path.exists(file_path):
        print(f"错误: 文件 {file_path} 不存在")
        return False

    try:
        # 读取Excel文件
        excel = pd.ExcelFile(file_path)
        sheets = excel.sheet_names

        print(f"\n检查Excel文件: {file_path}")
        print(f"包含的表: {sheets}")

        if expected_tables:
            missing_tables = set(expected_tables) - set(sheets)
            if missing_tables:
                print(f"错误: 缺少表 {missing_tables}")
                return False

        # 检查每个表的数据
        for sheet in sheets:
            df = pd.read_excel(file_path, sheet_name=sheet)
            print(f"\n表 {sheet}:")
            print(f"- 行数: {len(df)}")
            print(f"- 列数: {len(df.columns)}")
            print(f"- 列名: {list(df.columns)}")

        return True
    except Exception as e:
        print(f"检查Excel文件时出错: {str(e)}")
        return False


def run_tests():
    # 创建测试目录
    test_dir = "test_output"
    os.makedirs(test_dir, exist_ok=True)

    # 测试用例
    tests = [
        {
            "name": "生成少量数据（所有表）",
            "args": [
                "generate",
                "--count",
                "5",
                "--output",
                os.path.join(test_dir, "test_all.xlsx"),
            ],
            "check_file": os.path.join(test_dir, "test_all.xlsx"),
            "expected_tables": ["Book", "Reader", "Admin", "Borrow"],
        },
        {
            "name": "只生成图书表数据",
            "args": [
                "generate",
                "--table",
                "book",
                "--count",
                "5",
                "--output",
                os.path.join(test_dir, "test_books.xlsx"),
            ],
            "check_file": os.path.join(test_dir, "test_books.xlsx"),
            "expected_tables": ["Book"],
        },
        {
            "name": "生成大量数据",
            "args": [
                "generate",
                "--count",
                "200",
                "--output",
                os.path.join(test_dir, "test_large.xlsx"),
            ],
            "check_file": os.path.join(test_dir, "test_large.xlsx"),
            "expected_tables": ["Book", "Reader", "Admin", "Borrow"],
        },
    ]

    # 运行测试
    print("开始测试...")
    print(f"测试时间: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}")
    print(f"测试输出目录: {test_dir}")

    success_count = 0
    for test in tests:
        if run_test(test["name"], test["args"]):
            if check_excel_file(test["check_file"], test["expected_tables"]):
                success_count += 1
                print(f"测试 {test['name']} 通过")
            else:
                print(f"测试 {test['name']} 失败: Excel文件检查未通过")
        else:
            print(f"测试 {test['name']} 失败: 命令执行出错")

    # 打印测试结果
    print("\n=== 测试结果汇总 ===")
    print(f"总测试数: {len(tests)}")
    print(f"通过数: {success_count}")
    print(f"失败数: {len(tests) - success_count}")


if __name__ == "__main__":
    run_tests()

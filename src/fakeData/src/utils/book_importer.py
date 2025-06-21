import pandas as pd
from typing import List, Dict, Any


def import_books_from_file(file_path: str) -> List[Dict[str, Any]]:
    """
    从文件导入书籍数据
    支持的文件格式：CSV, Excel
    文件必须包含以下列：
    - BookName: 书名
    - Author: 作者
    - ISBN: ISBN号
    - Price: 价格
    - Inventory: 库存数量
    - ShelfCode: 书架编号
    """
    # 根据文件扩展名决定读取方式
    if file_path.endswith(".csv"):
        df = pd.read_csv(file_path)
    elif file_path.endswith((".xlsx", ".xls")):
        df = pd.read_excel(file_path)
    else:
        raise ValueError("不支持的文件格式，请使用CSV或Excel文件")

    # 检查必要的列是否存在
    required_columns = ["BookName", "Author", "ISBN", "Price", "Inventory", "SlotCode"]
    missing_columns = [col for col in required_columns if col not in df.columns]
    if missing_columns:
        raise ValueError(f"文件缺少必要的列: {', '.join(missing_columns)}")

    # 处理数据
    books = []
    for _, row in df.iterrows():
        book = {
            "BookName": str(row["BookName"]).strip(),
            "Author": str(row["Author"]).strip(),
            "ISBN": str(row["ISBN"]).strip(),
            "Price": float(row["Price"]),
            "Inventory": int(row["Inventory"]),
            "Picture": f"/images/{row['BookName']}{row['Author']}.jpg",
            "SlotCode": str(row["SlotCode"]).strip(),
        }
        books.append(book)

    return books


def validate_books(
    books: List[Dict[str, Any]], valid_slotcodes: List[str] = None
) -> List[str]:
    """
    验证书籍数据的有效性
    返回错误信息列表
    """
    errors = []
    for i, book in enumerate(books, 1):
        # 检查必填字段
        if not book["BookName"]:
            errors.append(f"第{i}行: 书名为空")
        if not book["Author"]:
            errors.append(f"第{i}行: 作者为空")
        if not book["ISBN"]:
            errors.append(f"第{i}行: ISBN为空")

        # 检查ISBN格式（简单检查）
        if not book["ISBN"].replace("-", "").isdigit():
            errors.append(f"第{i}行: ISBN格式不正确")

        # 检查价格
        if book["Price"] <= 0:
            errors.append(f"第{i}行: 价格必须大于0")

        # 检查库存
        if book["Inventory"] < 0:
            errors.append(f"第{i}行: 库存不能为负数")

        # 检查格子编号
        if not book["SlotCode"]:
            errors.append(f"第{i}行: 格子编号为空")
        elif valid_slotcodes is not None and book["SlotCode"] not in valid_slotcodes:
            errors.append(
                f"第{i}行: 格子编号 {book['SlotCode']} 不存在于 BookShelfSlot"
            )

    return errors

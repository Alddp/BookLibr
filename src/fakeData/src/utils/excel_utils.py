import pandas as pd


def save_to_excel(data_dict, filename="library_data.xlsx"):
    """
    将数据保存到Excel文件中
    """
    with pd.ExcelWriter(filename) as writer:
        for sheet_name, data in data_dict.items():
            df = pd.DataFrame(data)
            df.to_excel(writer, sheet_name=sheet_name, index=False)


def import_from_excel(filename, conn_str):
    """
    从Excel文件导入数据到数据库
    """
    try:
        # 读取所有sheet
        data_dict = {}
        excel_data = pd.read_excel(filename, sheet_name=None)

        # 将每个sheet转换为字典列表
        for sheet_name, df in excel_data.items():
            data_dict[sheet_name] = df.to_dict("records")

        # 使用数据库操作函数插入数据
        from src.database.db_operations import insert_into_sqlserver

        insert_into_sqlserver(data_dict, conn_str)

    except Exception as e:
        print(f"从Excel导入数据时发生错误: {str(e)}")
        raise

import pandas as pd
import os


def save_to_excel(data, filename):
    """
    将数据保存到Excel文件
    如果文件已存在，则追加数据到相应的sheet中，保留其他sheet
    """
    try:
        # 检查文件是否存在
        if os.path.exists(filename):
            # 读取现有的Excel文件
            existing_data = pd.read_excel(filename, sheet_name=None)

            # 更新数据
            for sheet_name, df in data.items():
                if sheet_name in existing_data:
                    # 如果sheet已存在，追加数据
                    existing_df = existing_data[sheet_name]
                    new_df = pd.DataFrame(df)
                    # 合并数据并去重
                    combined_df = pd.concat([existing_df, new_df], ignore_index=True)
                    combined_df = combined_df.drop_duplicates()
                    data[sheet_name] = combined_df
                else:
                    # 如果sheet不存在，直接使用新数据
                    data[sheet_name] = pd.DataFrame(df)

            # 将现有的其他sheet添加到data中
            for sheet_name, df in existing_data.items():
                if sheet_name not in data:
                    data[sheet_name] = df
        else:
            # 如果文件不存在，将所有数据转换为DataFrame
            for sheet_name, df in data.items():
                data[sheet_name] = pd.DataFrame(df)

        # 保存到Excel
        with pd.ExcelWriter(filename, engine="openpyxl") as writer:
            for sheet_name, df in data.items():
                df.to_excel(writer, sheet_name=sheet_name, index=False)

        print(f"数据已保存到Excel文件: {filename}")

    except Exception as e:
        print(f"保存到Excel时发生错误: {str(e)}")
        raise


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
            # 确保所有列都被转换为字符串类型
            for col in df.columns:
                if col in ["ISBN", "CardNum", "Phone", "StudentID", "SlotCode"]:
                    df[col] = df[col].astype(str)
                elif col in [
                    "Price",
                    "Inventory",
                    "SlotId",
                    "Floor",
                    "RowNumber",
                    "ColumnNumber",
                    "Level",
                ]:
                    df[col] = pd.to_numeric(df[col], errors="coerce")
                elif col in ["Start_Time", "Ending_Time", "BorrowDate", "ReturnDate"]:
                    df[col] = pd.to_datetime(df[col], errors="coerce")

            # 将 NaN 值替换为 None
            df = df.replace({pd.NA: None, pd.NaT: None})

            data_dict[sheet_name] = df.to_dict("records")

        # 如果提供了数据库连接字符串，则插入数据
        if conn_str:
            from src.database.db_operations import insert_into_sqlserver

            insert_into_sqlserver(data_dict, conn_str)
            print(f"成功从 {filename} 导入数据到数据库")

        return data_dict

    except Exception as e:
        print(f"从Excel导入数据时发生错误: {str(e)}")
        raise

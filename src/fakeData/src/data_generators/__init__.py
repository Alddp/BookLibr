"""
数据生成器模块
用于生成图书管理系统的测试数据
"""

from .generators import (
    generate_bookshelves,
    generate_bookshelfslots,
    generate_books,
    generate_readers,
    generate_admins,
    generate_borrows,
)

# 定义使用 from src.data_generators import * 时能导入的内容
__all__ = [
    "generate_bookshelves",
    "generate_bookshelfslots",
    "generate_books",
    "generate_readers",
    "generate_admins",
    "generate_borrows",
]

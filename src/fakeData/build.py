import os
import shutil
import subprocess


def build():
    # 清理旧的构建文件
    if os.path.exists("build"):
        shutil.rmtree("build")
    if os.path.exists("dist"):
        shutil.rmtree("dist")

    # 使用PyInstaller打包
    subprocess.run(
        [
            "pyinstaller",
            "--clean",  # 清理临时文件
            "--noconfirm",  # 不询问确认
            "library_tool.spec",
        ]
    )

    # 目标目录
    target_dir = r"D:\Code\BookLiber\BookLiber\bin\Debug\tools"

    # 确保目标目录存在
    os.makedirs(target_dir, exist_ok=True)

    # 源文件路径
    source_file = os.path.join("dist", "library_tool.exe")

    # 目标文件路径
    target_file = os.path.join(target_dir, "library_tool.exe")

    # 复制文件
    shutil.copy2(source_file, target_file)

    print(f"打包完成！可执行文件已复制到 {target_file}")


if __name__ == "__main__":
    build()

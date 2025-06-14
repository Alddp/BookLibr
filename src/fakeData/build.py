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

    print("打包完成！可执行文件位于 dist/library_tool.exe")


if __name__ == "__main__":
    build()

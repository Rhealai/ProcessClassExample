Imports System.IO

Module Module1

    Sub Main()
        Console.Write("Hello")
        Console.ReadKey()

        Console.Write(RunCMD("dir"))
        Console.ReadKey()

        'Dim Dir As String = "C:\Program Files\Opera"
        'Directory.SetCurrentDirectory(Dir)
        'RunWinApplication("")
        'Console.ReadKey()


        'Console.Write(Directory.GetCurrentDirectory)
        Console.WriteLine(RunBat())
        Console.ReadKey()

        'Process.Start("notepad.exe", "C:\UsbDsoData\list.txt")

    End Sub

    Private Function RunBat() As String
        Dim p As Process = New Process()
        p.StartInfo.FileName = "cmd.exe"

        p.StartInfo.UseShellExecute = False
        p.StartInfo.RedirectStandardInput = True
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.CreateNoWindow = True
        p.Start()

        p.StandardInput.WriteLine("C:\run.bat")
        p.StandardInput.WriteLine("exit")

        Return p.StandardOutput.ReadToEnd()

    End Function

    Private Function RunCMD(ByVal command As String) As String
        Dim p As Process = New Process()
        p.StartInfo.FileName = "cmd.exe"

        p.StartInfo.UseShellExecute = False
        p.StartInfo.RedirectStandardInput = True
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.CreateNoWindow = True
        p.Start()

        p.StandardInput.WriteLine(command)
        p.StandardInput.WriteLine("exit")

        Return p.StandardOutput.ReadToEnd()

    End Function

    Private Function RunWinApplication(ByVal command As String) As String
        '實例一個Process類，啟動一個獨立p進程
        Dim p As Process = New Process()

        'Process類有一個StartInfo屬性，這個是ProcessStartInfo類，包括了一些屬性和方法，下面我們用到了他的幾個屬性：

        p.StartInfo.WorkingDirectory = "C:\Program Files\Opera"
        p.StartInfo.FileName = "launcher.exe"           '設定程序名

        'p.StartInfo.Arguments = "/c " + command    '設定程式執行參數

        p.StartInfo.UseShellExecute = False        '關閉Shell的使用
        p.StartInfo.RedirectStandardInput = True   '重定向標準輸入
        p.StartInfo.RedirectStandardOutput = True  '重定向標準輸出
        p.StartInfo.RedirectStandardError = True   '重定向錯誤輸出
        p.StartInfo.CreateNoWindow = False          '設置顯示窗口

        p.Start() '啟動
        Return p.StandardOutput.ReadToEnd()        '從輸出流取得命令執行結果

    End Function

End Module

Imports System.Net

Module Module1

    Sub Main()

        Dim client As New WebClientWithCookies

        Dim strURL As String = String.Concat("https://www.bestattungwien.at/eportal2/fhw/cal/submitCalender.do?" &
                                                 "searchfield={datum}&" &
                                                 "progId=83491&" &
                                                 "datum=03.11.2017") '" & [String].Format("{0:dd.MM.yyyy}", dt.[Date])

        Dim myString = "https://www.bestattungwien.at/eportal2/fhw/cal/submitCalender.do?&searchfield={datum}&progId=83491&datum=03.11.2017"

        Dim pContent As String = String.Empty, maxloop As Integer = 0, url As Uri

        Do Until maxloop = 3
            pContent = String.Empty
            url = New Uri(strURL, UriKind.RelativeOrAbsolute)
            pContent = client.DownloadString(url)
            IO.File.WriteAllText("c:\tmp\Response_test_" & maxloop & ".txt", pContent)
            maxloop += 1
        Loop

        'Dim myString = "https://www.bestattungwien.at/eportal2/fhw/cal/submitCalender.do?&searchfield={datum}&progId=83491&datum=03.11.2017"

        'url = New Uri(myString, UriKind.RelativeOrAbsolute)
        'Console.WriteLine(client.DownloadString(url))
        'Console.WriteLine(client.DownloadString(url))
        'Console.WriteLine(client.DownloadString(url))

        'IO.File.WriteAllText("c:\tmp\Response_test_X.txt", pContent)
        Console.ReadLine()

    End Sub

End Module


Class WebClientWithCookies
    Inherits WebClient

    Private _container As New CookieContainer()

    Protected Overrides Function GetWebRequest(ByVal address As Uri) As WebRequest

        Dim HttpWebReq As HttpWebRequest = CType(MyBase.GetWebRequest(address), HttpWebRequest)

        If Not HttpWebReq Is Nothing Then

            HttpWebReq.Method = "Post"
            HttpWebReq.CookieContainer = _container
            HttpWebReq.ContentType = "application/x-www-form-urlencoded"

        End If

        Return HttpWebReq

    End Function
End Class
Imports System.Net.Http
Imports Newtonsoft.Json

Public Class ApiService
    Private ReadOnly client As New HttpClient()

    Public Sub New()
        client.BaseAddress = New Uri("https://localhost:7097/")
        client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))
    End Sub

    Public Async Function GetArtistsAsync() As Task(Of List(Of Artist))
        Dim response = Await client.GetAsync("api/artist")
        If response.IsSuccessStatusCode Then
            Dim json = Await response.Content.ReadAsStringAsync()
            Return JsonConvert.DeserializeObject(Of List(Of Artist))(json)
        End If
        Return New List(Of Artist)()
    End Function
End Class

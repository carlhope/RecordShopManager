Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class ApiService
    Private ReadOnly client As New HttpClient()

    Public Sub New()
        client.BaseAddress = New Uri("https://localhost:7097/")
        client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))
    End Sub
    ' Artist CRUD Operations
    Public Async Function GetArtistsAsync() As Task(Of List(Of Artist))
        Dim response = Await client.GetAsync("api/artist")
        If response.IsSuccessStatusCode Then
            Dim json = Await response.Content.ReadAsStringAsync()
            Return JsonConvert.DeserializeObject(Of List(Of Artist))(json)
        End If
        Return New List(Of Artist)()
    End Function

    Public Async Function GetArtistByIdAsync(id As Integer) As Task(Of Artist)
        Using client As New HttpClient()
            client.BaseAddress = New Uri("https://localhost:7097/")
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))

            Dim response = Await client.GetAsync($"api/artist/{id}")
            If response.IsSuccessStatusCode Then
                Dim json = Await response.Content.ReadAsStringAsync()
                Dim artist = JsonConvert.DeserializeObject(Of Artist)(json)
                Return artist
            Else
                Return Nothing
            End If
        End Using
    End Function

    Public Async Function AddArtistAsync(artist As Artist) As Task(Of Boolean)
        Using client As New HttpClient()
            client.BaseAddress = New Uri("https://localhost:7097/")
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))
            artist.Id = 0
            artist.AlbumJunction = New List(Of ArtistAlbumJunction)()


            Dim json = JsonConvert.SerializeObject(artist)
            Dim content = New StringContent(json, Encoding.UTF8, "application/json")

            Dim response = Await client.PostAsync("api/artist", content)
            Return response.IsSuccessStatusCode
        End Using
    End Function

    Public Async Function UpdateArtistAsync(artist As Artist) As Task(Of Boolean)
        Using client As New HttpClient()
            client.BaseAddress = New Uri("https://localhost:7097/")
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))

            Dim json = JsonConvert.SerializeObject(artist)
            Dim content = New StringContent(json, Encoding.UTF8, "application/json")

            Dim response = Await client.PutAsync($"api/artist/{artist.Id}", content)
            Return response.IsSuccessStatusCode
        End Using
    End Function
    Public Async Function DeleteArtistAsync(id As Integer) As Task(Of Boolean)
        Using client As New HttpClient()
            client.BaseAddress = New Uri("https://localhost:7097/")
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))

            Dim response = Await client.DeleteAsync($"api/artist/{id}")
            Return response.IsSuccessStatusCode
        End Using
    End Function

    ' Album CRUD Operations
    Public Async Function GetAlbumsAsync() As Task(Of List(Of Album))
        Using client As New HttpClient()
            client.BaseAddress = New Uri("https://localhost:7097/")
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))

            Dim response = Await client.GetAsync("api/album")
            If response.IsSuccessStatusCode Then
                Dim json = Await response.Content.ReadAsStringAsync()
                Return JsonConvert.DeserializeObject(Of List(Of Album))(json)
            End If
            Return New List(Of Album)()
        End Using
    End Function

    Public Async Function GetAlbumByIdAsync(id As Integer) As Task(Of Album)
        Using client As New HttpClient()
            client.BaseAddress = New Uri("https://localhost:7097/")
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))

            Dim response = Await client.GetAsync($"api/album/{id}")
            If response.IsSuccessStatusCode Then
                Dim json = Await response.Content.ReadAsStringAsync()
                Return JsonConvert.DeserializeObject(Of Album)(json)
            Else
                Return Nothing
            End If
        End Using
    End Function

    Public Async Function AddAlbumAsync(album As Album) As Task(Of Boolean)
        Using client As New HttpClient()
            client.BaseAddress = New Uri("https://localhost:7097/")
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))

            Dim json = JsonConvert.SerializeObject(album)
            Dim content = New StringContent(json, Encoding.UTF8, "application/json")

            Dim response = Await client.PostAsync("api/album", content)
            Return response.IsSuccessStatusCode
        End Using
    End Function

    Public Async Function UpdateAlbumAsync(album As Album) As Task(Of Boolean)
        Using client As New HttpClient()
            client.BaseAddress = New Uri("https://localhost:7097/")
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))

            Dim json = JsonConvert.SerializeObject(album)
            Dim content = New StringContent(json, Encoding.UTF8, "application/json")

            Dim response = Await client.PutAsync($"api/album/{album.Id}", content)
            Return response.IsSuccessStatusCode
        End Using
    End Function

    Public Async Function DeleteAlbumAsync(id As Integer) As Task(Of Boolean)
        Using client As New HttpClient()
            client.BaseAddress = New Uri("https://localhost:7097/")
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))

            Dim response = Await client.DeleteAsync($"api/album/{id}")
            Return response.IsSuccessStatusCode
        End Using
    End Function
End Class

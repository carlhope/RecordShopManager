Public Class ArtistPanel
    Private Async Sub ArtistPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadArtistDataAsync()
    End Sub
    Private Async Function LoadArtistDataAsync() As Task
        Try
            Dim service As New ApiService()
            Dim artists = Await service.GetArtistsAsync()
            dgvArtists.DataSource = artists
        Catch ex As Exception
            MessageBox.Show("Failed to load artists: " & ex.Message)
        End Try
    End Function
End Class

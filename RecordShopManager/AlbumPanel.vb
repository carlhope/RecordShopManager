Public Class AlbumPanel
    Private Async Sub AlbumPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadAlbumDataAsync()
    End Sub
End Class

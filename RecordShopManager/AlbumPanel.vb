Public Class AlbumPanel
    Private Async Sub AlbumPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadAlbumDataAsync()
    End Sub

    Private Async Sub BtnAddAlbum_Click(sender As Object, e As EventArgs) Handles BtnAddAlbum.Click
        Dim addForm As New AddAlbumForm()
        If addForm.ShowDialog() = DialogResult.OK Then
            Await LoadAlbumDataAsync()
        End If
    End Sub
End Class

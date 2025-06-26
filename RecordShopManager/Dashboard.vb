Public Class Dashboard
    Private Sub BtnArtist_Click(sender As Object, e As EventArgs) Handles BtnArtist.Click
        PnlContent.Controls.Clear()
        Dim artistUI As New ArtistPanel()
        artistUI.Dock = DockStyle.Fill
        PnlContent.Controls.Add(artistUI)
    End Sub

    Private Sub BtnAlbum_Click(sender As Object, e As EventArgs) Handles BtnAlbum.Click
        PnlContent.Controls.Clear()
        Dim albumUI As New AlbumPanel()
        albumUI.Dock = DockStyle.Fill
        PnlContent.Controls.Add(albumUI)
    End Sub
End Class

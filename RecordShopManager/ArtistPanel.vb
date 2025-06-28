Public Class ArtistPanel
    Private Async Sub ArtistPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadArtistDataAsync()
    End Sub
    Private Async Function LoadArtistDataAsync() As Task
        Try
            Dim service As New ApiService()
            Dim artists = Await service.GetArtistsAsync()
            dgvArtists.DataSource = artists
            If Not dgvArtists.Columns.Contains("colDelete") Then
                Dim deleteButton As New DataGridViewButtonColumn()
                With deleteButton
                    .Name = "colDelete"
                    .HeaderText = "Actions"
                    .Text = "Delete"
                    .UseColumnTextForButtonValue = True
                End With
                dgvArtists.Columns.Add(deleteButton)
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to load artists: " & ex.Message)
        End Try
    End Function

    Private Async Sub dgvArtists_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArtists.CellClick
        If e.RowIndex >= 0 AndAlso dgvArtists.Columns(e.ColumnIndex).Name = "colDelete" Then
            Dim artist = TryCast(dgvArtists.Rows(e.RowIndex).DataBoundItem, Artist)
            If artist IsNot Nothing Then
                Dim confirm = MessageBox.Show($"Delete artist '{artist.Name}'?", "Confirm Delete", MessageBoxButtons.YesNo)
                If confirm = DialogResult.Yes Then
                    Dim apiService As New ApiService()
                    Dim success = Await apiService.DeleteArtistAsync(artist.Id)
                    If success Then
                        MessageBox.Show("Artist deleted.")
                        Await LoadArtistDataAsync()
                    Else
                        MessageBox.Show("Something went wrong.")
                    End If
                End If
            End If
        End If
    End Sub
End Class

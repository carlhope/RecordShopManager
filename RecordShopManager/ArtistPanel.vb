Public Class ArtistPanel
    Private Async Sub ArtistPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadArtistDataAsync()
    End Sub
    Private Async Function LoadArtistDataAsync() As Task
        Try
            Dim apiService As New ApiService()
            Dim artists = Await apiService.GetArtistsAsync()

            ' Reset grid to start fresh
            dgvArtists.Columns.Clear()
            'Auto generate columns based on the Artist class properties
            dgvArtists.AutoGenerateColumns = True
            dgvArtists.DataSource = artists

            ' Add Edit column
            Dim editButton As New DataGridViewButtonColumn()
            With editButton
                .Name = "colEdit"
                .HeaderText = "Edit"
                .Text = "Edit"
                .UseColumnTextForButtonValue = True
            End With
            dgvArtists.Columns.Add(editButton)

            ' Add Delete column
            Dim deleteButton As New DataGridViewButtonColumn()
            With deleteButton
                .Name = "colDelete"
                .HeaderText = "Delete"
                .Text = "Delete"
                .UseColumnTextForButtonValue = True
            End With
            dgvArtists.Columns.Add(deleteButton)

        Catch ex As Exception
            MessageBox.Show("Failed to load artists: " & ex.Message)
        End Try
    End Function

    Private Async Sub dgvArtists_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArtists.CellClick
        If e.RowIndex < 0 Then Exit Sub

        Dim artist = TryCast(dgvArtists.Rows(e.RowIndex).DataBoundItem, Artist)
        If artist Is Nothing Then Exit Sub

        Dim columnName = dgvArtists.Columns(e.ColumnIndex).Name

        If columnName = "colDelete" Then
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

        ElseIf columnName = "colEdit" Then
            Dim editForm As New EditArtistForm(artist)
            If editForm.ShowDialog() = DialogResult.OK Then
                Await LoadArtistDataAsync()
            End If
        End If
    End Sub
End Class

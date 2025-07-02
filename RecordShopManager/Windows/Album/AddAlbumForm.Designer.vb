<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddAlbumForm
    Inherits System.Windows.Forms.Form

    Friend WithEvents txtTitle As TextBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnCancel As Button


    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(320, 240)
        Me.Text = "Add Album"
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterParent
        Me.MaximizeBox = False
        Me.MinimizeBox = False

        ' Title TextBox
        txtTitle = New TextBox() With {
        .PlaceholderText = "Album Title",
        .Location = New Point(20, 20),
        .Size = New Size(260, 25)
    }

        ' Description TextBox
        txtDescription = New TextBox() With {
        .PlaceholderText = "Album Description",
        .Location = New Point(20, 60),
        .Size = New Size(260, 60),
        .Multiline = True
    }

        ' Submit Button
        btnSubmit = New Button() With {
        .Text = "Submit",
        .Location = New Point(50, 140),
        .Size = New Size(100, 30)
    }

        ' Cancel Button
        btnCancel = New Button() With {
        .Text = "Cancel",
        .Location = New Point(160, 140),
        .Size = New Size(100, 30)
    }

        ' Add controls to the form
        Me.Controls.AddRange(New Control() {txtTitle, txtDescription, btnSubmit, btnCancel})
    End Sub
    Public Sub New()
        InitializeComponent()

        AddHandler btnSubmit.Click, AddressOf btnSubmit_Click
        AddHandler btnCancel.Click, Sub() Me.Close()
    End Sub
    Private Async Sub btnSubmit_Click(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtTitle.Text) Then
            MessageBox.Show("Please enter a title.")
            Exit Sub
        End If

        Dim newAlbum As New Album() With {
            .Title = txtTitle.Text.Trim(),
            .Description = txtDescription.Text.Trim()
        }

        Dim service As New ApiService()
        Dim success = Await service.AddAlbumAsync(newAlbum)

        If success Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Failed to add album.")
        End If
    End Sub
End Class

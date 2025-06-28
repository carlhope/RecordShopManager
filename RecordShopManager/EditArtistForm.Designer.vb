<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditArtistForm
    Inherits System.Windows.Forms.Form
    Private ReadOnly _artist As Artist
    Private WithEvents btnSubmit As Button
    Private txtName As TextBox


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
        components = New System.ComponentModel.Container
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Text = "EditArtistForm"

        txtName = New TextBox()
        txtName.Name = "txtName"
        txtName.Location = New Point(20, 40)
        txtName.Width = 240

        btnSubmit = New Button()
        btnSubmit.Text = "Save"
        btnSubmit.Location = New Point(20, 80)
        AddHandler btnSubmit.Click, AddressOf btnSubmit_Click

        Me.Controls.Add(txtName)
        Me.Controls.Add(btnSubmit)
    End Sub
    Public Sub New(artist As Artist)
        MyBase.New()
        InitializeComponent()
        _artist = artist
        txtName.Text = artist.Name
    End Sub
    Private Async Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        _artist.Name = txtName.Text.Trim()
        Dim apiService As New ApiService()
        Dim success = Await apiService.UpdateArtistAsync(_artist)
        If success Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub


End Class

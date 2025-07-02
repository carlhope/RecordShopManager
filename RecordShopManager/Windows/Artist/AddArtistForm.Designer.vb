<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddArtistForm
    Inherits System.Windows.Forms.Form

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
        components = New System.ComponentModel.Container
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Text = "AddArtistForm"
        Me.Size = New Size(300, 200)
        Me.StartPosition = FormStartPosition.CenterParent

        ' === Label for Name ===
        Dim lblName As New Label()
        lblName.Text = "Artist Name:"
        lblName.Location = New Point(20, 20)
        lblName.AutoSize = True

        ' === TextBox for Name Input ===
        Dim txtName As New TextBox()
        txtName.Name = "txtName"
        txtName.Location = New Point(20, 45)
        txtName.Width = 240

        ' === Submit Button ===
        btnSubmit = New Button()
        btnSubmit.Text = "Submit"
        btnSubmit.Location = New Point(20, 90)


        ' === Cancel Button ===

        btnCancel = New Button()
        btnCancel.Text = "Cancel"
        btnCancel.Location = New Point(120, 90)
        ' === Add controls to form ===
        Me.Controls.Add(lblName)
        Me.Controls.Add(txtName)
        Me.Controls.Add(btnSubmit)
        Me.Controls.Add(btnCancel)
    End Sub
    Public Sub New()
        InitializeComponent()
        AddHandler btnSubmit.Click, AddressOf btnSubmit_Click
        AddHandler btnCancel.Click, Sub() Me.Close()
    End Sub
    Private Async Sub btnSubmit_Click(sender As Object, e As EventArgs)
        Dim name = Me.Controls("txtName").Text.Trim()
        If String.IsNullOrEmpty(name) Then
            MessageBox.Show("Please enter an artist name.")
            Return
        End If

        Dim newArtist As New Artist With {.Name = name}
        Dim service As New ApiService()
        Dim success = Await service.AddArtistAsync(newArtist)

        If success Then
            MessageBox.Show("Artist added successfully!")
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Failed to add artist.")
        End If
    End Sub
End Class

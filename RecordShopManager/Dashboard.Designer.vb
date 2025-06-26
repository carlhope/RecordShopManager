<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Dashboard
    Inherits System.Windows.Forms.Form

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadArtistPanel()
    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        PnlSidebar = New Panel()
        BtnAlbum = New Button()
        BtnArtist = New Button()
        PnlContent = New Panel()
        PnlSidebar.SuspendLayout()
        SuspendLayout()
        ' 
        ' PnlSidebar
        ' 
        PnlSidebar.BackColor = SystemColors.ActiveCaption
        PnlSidebar.Controls.Add(BtnAlbum)
        PnlSidebar.Controls.Add(BtnArtist)
        PnlSidebar.Dock = DockStyle.Left
        PnlSidebar.Location = New Point(0, 0)
        PnlSidebar.Name = "PnlSidebar"
        PnlSidebar.Size = New Size(224, 450)
        PnlSidebar.TabIndex = 0
        ' 
        ' BtnAlbum
        ' 
        BtnAlbum.Location = New Point(0, 73)
        BtnAlbum.Name = "BtnAlbum"
        BtnAlbum.Size = New Size(224, 23)
        BtnAlbum.TabIndex = 1
        BtnAlbum.Text = "Albums"
        BtnAlbum.UseVisualStyleBackColor = True
        ' 
        ' BtnArtist
        ' 
        BtnArtist.Location = New Point(0, 31)
        BtnArtist.Name = "BtnArtist"
        BtnArtist.Size = New Size(224, 23)
        BtnArtist.TabIndex = 0
        BtnArtist.Text = "Artists"
        BtnArtist.UseVisualStyleBackColor = True
        ' 
        ' PnlContent
        ' 
        PnlContent.Dock = DockStyle.Fill
        PnlContent.Location = New Point(224, 0)
        PnlContent.Name = "PnlContent"
        PnlContent.Size = New Size(576, 450)
        PnlContent.TabIndex = 1
        ' 
        ' Dashboard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(PnlContent)
        Controls.Add(PnlSidebar)
        Name = "Dashboard"
        Text = "Record Shop Manager"
        PnlSidebar.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents PnlSidebar As Panel
    Friend WithEvents BtnArtist As Button
    Friend WithEvents PnlContent As Panel
    Friend WithEvents BtnAlbum As Button

    Private Sub LoadArtistPanel()
        PnlContent.Controls.Clear()
        Dim artistUI As New ArtistPanel()
        artistUI.Dock = DockStyle.Fill
        PnlContent.Controls.Add(artistUI)
    End Sub

End Class

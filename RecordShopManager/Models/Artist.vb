Imports Newtonsoft.Json

Public Class Artist
    <JsonProperty("id")>
    Public Property Id As Integer

    <JsonProperty("name")>
    Public Property Name As String

    <JsonProperty("albumJunction")>
    Public Property AlbumJunction As List(Of ArtistAlbumJunction)
End Class

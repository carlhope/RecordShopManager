Imports Newtonsoft.Json

Public Class Album
    <JsonProperty("id")>
    Public Property Id As Integer

    <JsonProperty("title")>
    Public Property Title As String

    <JsonProperty("description")>
    Public Property Description As String

    '<JsonProperty("artistJunction")>
    'Public Property ArtistJunction As List(Of ArtistAlbumJunction)

    '<JsonProperty("genres")>
    'Public Property Genres As List(Of AlbumGenre)
End Class

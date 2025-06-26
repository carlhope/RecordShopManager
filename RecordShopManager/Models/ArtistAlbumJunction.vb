Imports Newtonsoft.Json

Public Class ArtistAlbumJunction
    <JsonProperty("id")>
    Public Property Id As Integer

    <JsonProperty("artistId")>
    Public Property ArtistId As Integer

    <JsonProperty("albumId")>
    Public Property AlbumId As Integer

    <JsonProperty("artist")>
    Public Property Artist As Artist

    <JsonProperty("album")>
    Public Property Album As Album
End Class

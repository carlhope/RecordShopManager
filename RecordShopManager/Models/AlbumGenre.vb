Imports Newtonsoft.Json

Public Class AlbumGenre
    <JsonProperty("id")>
    Public Property Id As Integer

    <JsonProperty("albumId")>
    Public Property AlbumId As Integer

    <JsonProperty("genre")>
    Public Property Genre As Genre

    <JsonProperty("album")>
    Public Property Album As Album
End Class

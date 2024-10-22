namespace WEBPHUB.Models;

//this is for bulk encoding and decoding views
public class ImageModel
{
    public string Location { get; }
    public int ID { get; }
    public long Size { get; }

    public ImageModel(string path, int id, long size) => (Location, ID, Size) = (path, id, size);
}

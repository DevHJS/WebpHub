namespace WEBPHUB.InternalServices.OptionsBuilder;

public class DecodeOptionsBuilderService
{
    public string NoDither { get; set; } = "-nodither";
    public string Dither { get; set; } = string.Empty;
    public string NoFancy { get; set; } = string.Empty;
    public string NoFilter { get; set; } = string.Empty;
    public string Format { get; set; }

    public string MultiThreading { get; set; } = string.Empty;
    public string NoAsm { get; set; } = string.Empty;

    public string ConstructOptions()
    {
        var properties = this.GetType().GetProperties();
        StringBuilder builder = new("");
        foreach (var property in properties)
            builder.Append($"{property.GetValue(this)} ");

        return builder.ToString();
    }
}

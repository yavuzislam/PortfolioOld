namespace Portfolio.Models.AboutDtos;

public class CreateAboutDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string ImagePath { get; set; }
}

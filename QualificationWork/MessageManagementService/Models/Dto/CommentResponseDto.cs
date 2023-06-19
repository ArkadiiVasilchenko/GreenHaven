namespace MessageManagementService.Models.Dto
{
    public class CommentResponseDto
    {
        public CommentResponseDto(){}

        public CommentResponseDto(string author, string text)
        {
            Author = author;
            Text = text;
        }

        public string Author { get; set; }
        public string Text { get; set; }


    }
}

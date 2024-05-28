namespace PitagorasSNS.API.SocialNetworkService.Domain.Models
{
	public class Class : IEntity
	{
		public string Id { get; set; } = string.Empty;
		public string ClassCode { get; set; } = string.Empty;
		public string TeacherId { get; set; } = string.Empty;
		public string TeacherCode { get; set; } = string.Empty;
		public IEnumerable<string> StudentsEnrolledId { get; set; } = new List<string>();
		public IEnumerable<string> StudentsEnrolledCode { get; set; } = new List<string>();
		public string CourseId { get; set; } = string.Empty;
		public string CourseCode { get; set; } = string.Empty;
		public float AverageClassScore { get; set; }
	}
}
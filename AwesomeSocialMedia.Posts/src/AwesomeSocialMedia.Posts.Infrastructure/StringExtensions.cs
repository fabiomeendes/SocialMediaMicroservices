using System;
using System.Text;

namespace AwesomeSocialMedia.Posts.Infrastructure
{
	public static class StringExtensions
	{
		public static string ToDashCase(this string input)
		{
            var sb = new StringBuilder();
            for (var i = 0; i < input.Length; i++)
                if (i != 0 && char.IsUpper(input[i]))
                    sb.Append($"-{input[i]}");
                else
                    sb.Append(input[i]);

            return sb.ToString().ToLower();
        }
	}
}


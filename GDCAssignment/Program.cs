using System.Text.RegularExpressions;

namespace GDCAssignment
{
	class Program
	{
		static void Main(string[] args)
		{			
			
			//Ask user for file name
			Console.WriteLine("Input file name:");
			string filename = Console.ReadLine();
			
			//We are only dealing with .csv files
			if (!filename.EndsWith(".csv"))
			{
				Console.WriteLine("File type must be .csv. Type in the full file name with extension");
				return;
			}
			
			//Check if file exists in current directory
			bool exists = File.Exists(filename) ? true: false;
				
			//If it exists, create lists of valid and invalid email addresses using built-in IsValidEmail
			if (exists)
			{
				//Read all lines of .csv file
				string[] lines = System.IO.File.ReadAllLines(filename);
				
				//Create the two lists for valid and invalid addresses
				List<string> validEmails = new List<string>();
				List<string> invalidEmails = new List<string>();
				
				//For each line of the string array (lines):
				foreach(string line in lines)
				{	
					//Split each line into strings, splitting on the comma
					string[] columns = line.Split(',');
					
					//The email address is always in index 2
					string currentEmail = columns[2];
					
					//Pass the address to the function and return true if valid, false if invalid
					bool valid = IsValidEmailAddress(currentEmail);
					
					//Add to the validEmails list if valid
					if (valid)
					{
						validEmails.Add(currentEmail);
					}
					
					//Add to the invalidEmails list if invalid
					else
					{
						invalidEmails.Add(currentEmail);
					}
				}
				
				//Output the results to console
				Console.WriteLine("");
				Console.WriteLine("Valid Email Addresses:");
				
				for (int i=0; i < validEmails.Count; i++)
					Console.WriteLine(validEmails[i]);
				
				Console.WriteLine("");
				Console.WriteLine("Invalid Email Addresses:");
				
				for (int i=0; i < invalidEmails.Count; i++)
					Console.WriteLine(invalidEmails[i]);
				
			}
			
			//If .csv file didn't exist, output error message to console
			else
			{
				Console.WriteLine("Error: File does not exist");
			}
		}
					
	/*Function to test if email address is valid or not
	Credits for regex function: 
	https://stackoverflow.com/questions/36035941/check-valid-email-address-in-c-sharp	
	*/
	
	public static bool IsValidEmailAddress(string emailaddress)
    {
        try
        {
            Regex rx = new Regex(
        @"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
            return rx.IsMatch(emailaddress);
        }
        catch (FormatException)
        {
            return false;
        }
	}
	
	}
}
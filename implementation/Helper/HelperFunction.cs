// This Code Belong For Diamond Key Software solutions
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacistsSyndicateReNew.implementation.Helper
{
    public static class HelperFunction
    {
        public static string[] CleanAndSeparateNameParts(string fullName)
        {
            // 1. Define common titles (you can expand this list)
            string[] commonTitles = {
            "الأستاذ",
            "د.",
            "د",
            "دكتور",
            "صيدلي",
            "مهندس",
            "الشيخ",
            "Mr.",
            "Dr.",
            "Eng."
            };

            string cleanedName = fullName.Trim(); // Start by trimming leading/trailing spaces

            // 2. Iterate through the titles and remove them if found at the start
            foreach (string title in commonTitles)
            {
                // Check if the name starts with the title, followed by a space
                if (cleanedName.StartsWith(title + " ", StringComparison.OrdinalIgnoreCase))
                {
                    // Remove the title and the trailing space
                    cleanedName = cleanedName.Substring(title.Length + 1).Trim();
                    break; // Assuming only one title prefix is used
                }
            }

            // 3. Split the cleaned name
            // Use the space character as the separator
            string[] nameParts = cleanedName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return nameParts;
        }

        public static string NormalizeArabicNameForMatch(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return name;
            }
            // 1. Normalize the text
            // The following replacements simplify various Alif forms (with Hamza or Madda) 
            // to the plain Alif (ا).
            string normalizedName = name
                // Replace Alif with Hamza Above (أ) with plain Alif (ا)
                .Replace('أ', 'ا')
                // Replace Alif with Hamza Below (إ) with plain Alif (ا)
                .Replace('إ', 'ا')
                // Replace Alif with Madda Above (آ) with plain Alif (ا)
                .Replace('آ', 'ا')
                // Replace Taa Marbutah (ة) with Haa (ه) - sometimes useful for matching
                .Replace('ة', 'ه');

            // You might also want to normalize Ya (ی) to plain Ya (ي) 
            // (This is less common for *name* matching but useful for general text)
            // .Replace('ى', 'ي'); 

            // 2. Remove any remaining diacritics (Harakat) or Tatweel (ـ)
            // This uses a regular expression to strip all other combining marks and accents
            normalizedName = System.Text.RegularExpressions.Regex.Replace(
                normalizedName,
                @"[\u064B-\u065F\u0670\u06D6-\u06DC\u06DF-\u06E8\u06EA-\u06ED]",
                string.Empty
            );

            // 3. Trim whitespace and return
            return normalizedName.Trim();
        }

        public static bool MatchingStrings(string s1, string s2)
        {
            string normalizedS1 = NormalizeArabicNameForMatch(s1);
            string normalizedS2 = NormalizeArabicNameForMatch(s2);
            return normalizedS1 == normalizedS2;
        }

        public static string[] ProcessAndSplitArabicName(string fullName)
        {
            // --- 1. CLEANING (Remove Titles) ---

            string cleanedName = fullName.Trim();
            string[] commonTitles = { "الأستاذ", "د.", "د", "دكتور", "مهندس", "الشيخ", "الصيدلي" };

            foreach (string title in commonTitles)
            {
                // Use OrdinalIgnoreCase for case-insensitive checking (even though Arabic is often handled differently, this is good practice)
                if (cleanedName.StartsWith(title + " ", StringComparison.OrdinalIgnoreCase))
                {
                    cleanedName = cleanedName.Substring(title.Length + 1).Trim();
                    break;
                }
            }

            // --- 2. NORMALIZATION (Handle Hamza Variations) ---

            if (string.IsNullOrEmpty(cleanedName))
            {
                return new string[0]; // Return empty array if name is empty after cleaning
            }

            string normalizedName = cleanedName
                // Normalize various Alif forms (أ, إ, آ) to plain Alif (ا)
                .Replace('أ', 'ا')
                .Replace('إ', 'ا')
                .Replace('آ', 'ا')
                // Normalize Taa Marbutah (ة) to Haa (ه)
                .Replace('ة', 'ه');

            // Remove remaining diacritics (Harakat)
            normalizedName = System.Text.RegularExpressions.Regex.Replace(
                normalizedName,
                @"[\u064B-\u065F\u0670\u06D6-\u06DC\u06DF-\u06E8\u06EA-\u06ED]",
                string.Empty
            );

            // --- 3. SPLITTING (Separate Parts) ---

            string[] nameParts = normalizedName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return nameParts;
        }
    }
}
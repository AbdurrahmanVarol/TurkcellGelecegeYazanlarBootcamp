
Console.WriteLine("Lütfen şifrenizi giriniz: ");
var password = Console.ReadLine();
var result = CheckPassword(password);
Console.WriteLine(result);
Console.ReadKey();

string CheckPassword(string password)
{
    if (string.IsNullOrWhiteSpace(password))
        return "Şifre girmediniz.";
    if (password.Length < 6)
        return "Şifreniz 6 karakterden az olamaz";

    var hasNumber = password.Any(p => char.IsDigit(p));
    var hasLetter = password.Any(p => char.IsLetter(p));
    var hasPunctuatio = password.Any(p => char.IsPunctuation(p));

    if (hasLetter && hasNumber && hasPunctuatio)
        return "Şifreniz güçlü.";
    else if ((hasLetter && hasNumber) || (hasLetter && hasPunctuatio) || (hasNumber && hasPunctuatio))
        return "Şifreniz orta";
    else
        return "Şifreniz zayıf";
}
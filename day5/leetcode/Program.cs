public class Solution {
    public string GetHint(string secret, string guess) {
        // Determine first which digits are placed correctly
        // Store the number of digits using a frequency table
        var bullArr = new int[10];
        var secretArr = new int[10];
        var guessArr = new int[10];

        for (var i = 0; i < secret.Length; i++)
        {
            if (secret[i] == guess[i])
                bullArr[secret[i] - '0']++;

            secretArr[secret[i] - '0']++;
            guessArr[guess[i] - '0']++;

        }
        // Finally, iterate over the arrays and, if we find a match, extract the number of correctly placed digits before adding to cows
        var cows = 0;
        var bulls = 0;
        for (var i = 0; i < secretArr.Length; i++)
        {
            if (secretArr[i] > 0 && guessArr[i] > 0)
                cows += Math.Min(secretArr[i], guessArr[i]) - bullArr[i];
            bulls += bullArr[i];
        }
        return bulls.ToString() + 'A' + cows.ToString() + 'B';
    }    
}

public static class MysteryStack1 {
    public static string Run(string text) {
        var stack = new Stack<char>();
        foreach (var letter in text)
            stack.Push(letter);
            Console.WriteLine($"Stack: [{string.Join(", ", stack)}]");

        var result = "";
          Console.WriteLine($"Stack: [{string.Join(", ", stack)}]");
        while (stack.Count > 0)
            result += stack.Pop();

        return result;
    }
}
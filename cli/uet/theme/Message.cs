using System;

namespace UetDictionaryCli
{
  public static class Message
  {
    public static void Log(string str, MessageType type)
    {
      switch (type)
      {
        case MessageType.Info:
          Console.ForegroundColor = ConsoleColor.Cyan;
          break;
        case MessageType.Success:
          Console.ForegroundColor = ConsoleColor.Green;
          break;
        case MessageType.Warning:
          Console.ForegroundColor = ConsoleColor.Yellow;
          break;
        case MessageType.Danger:
          Console.ForegroundColor = ConsoleColor.Red;
          break;
        default:
          Console.ForegroundColor = ConsoleColor.White;
          break;
      }
      Console.WriteLine(str);
      Console.ForegroundColor = ConsoleColor.White;
    }
  }
}

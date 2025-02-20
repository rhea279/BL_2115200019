using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;

class Program
{
    static void Main()
    {
        using (AnonymousPipeServerStream pipeServer = new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable))
        using (AnonymousPipeClientStream pipeClient = new AnonymousPipeClientStream(PipeDirection.In, pipeServer.ClientSafePipeHandle))
        {
            Thread writerThread = new Thread(() => WriteData(pipeServer));
            Thread readerThread = new Thread(() => ReadData(pipeClient));

            writerThread.Start();
            readerThread.Start();

            writerThread.Join();
            readerThread.Join();
        }
    }

    static void WriteData(PipeStream pipe)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(pipe, Encoding.UTF8, 1024, leaveOpen: true))
            {
                writer.AutoFlush = true;
                for (int i = 1; i <= 5; i++)
                {
                    string message = $"Message {i} from Writer Thread";
                    Console.WriteLine($"Writing: {message}");
                    writer.WriteLine(message);
                    Thread.Sleep(1000); // Simulate processing delay
                }
            }
        }
        catch (IOException ioEx)
        {
            Console.WriteLine("Write Error: " + ioEx.Message);
        }
    }

    static void ReadData(PipeStream pipe)
    {
        try
        {
            using (StreamReader reader = new StreamReader(pipe, Encoding.UTF8, true, 1024, leaveOpen: true))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"Reading: {line}");
                }
            }
        }
        catch (IOException ioEx)
        {
            Console.WriteLine("Read Error: " + ioEx.Message);
        }
    }
}

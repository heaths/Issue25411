using Azure;
using Jobs;

JobsClient client = new(args[0]);
Operation<BinaryData> operation = await client.BeginAsync();

BinaryData result = await operation.WaitForCompletionAsync();
Console.WriteLine(result.ToString());

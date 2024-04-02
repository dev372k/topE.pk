using System;
using System.IO;
using Microsoft.Extensions.Configuration;

public sealed class Appsettings
{
    private static readonly object _lock = new object();
    private static volatile Appsettings _instance;

    private readonly string _name;
    private readonly string _email;
    private readonly string _password;
    private readonly string _host;
    private readonly int _port;

    private Appsettings()
    {
        var configurationBuilder = new ConfigurationBuilder();
        var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
        configurationBuilder.AddJsonFile(path, false);

        var root = configurationBuilder.Build();
        var mailSettings = root.GetSection("MailSettings");
        _name = mailSettings.GetSection("Name").Value;
        _email = mailSettings.GetSection("Email").Value;
        _password = mailSettings.GetSection("Password").Value;
        _host = mailSettings.GetSection("Host").Value;
        int.TryParse(mailSettings.GetSection("Port").Value, out _port);
    }

    public static Appsettings Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Appsettings();
                    }
                }
            }
            return _instance;
        }
    }

    public string Name { get => _name; }
    public string Email { get => _email; }
    public string Password { get => _password; }
    public string Host { get => _host; }
    public int Port { get => _port; }
}

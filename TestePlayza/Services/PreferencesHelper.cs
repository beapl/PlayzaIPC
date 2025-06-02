using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

public static class PreferencesHelper
{
    private const string PinKey = "ParentalControlPin";

    // Verifica se já existe um PIN configurado
    public static bool HasPin()
    {
        return Preferences.ContainsKey(PinKey);
    }

    // Salva o PIN nas Preferences
    public static void SetPin(string pin)
    {
        Preferences.Set(PinKey, pin);
    }

    // Recupera o PIN armazenado (ou string vazia se não existir)
    public static string GetPin()
    {
        return Preferences.Get(PinKey, string.Empty);
    }

    // Para remover o PIN (se precisar)
    public static void RemovePin()
    {
        Preferences.Remove(PinKey);
    }
}


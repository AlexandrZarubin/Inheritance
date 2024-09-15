#include <iostream>
#include <fstream>
#include <string>

using namespace std;
// ����� ��� ������ �����
class FileReader {
private:
    ifstream inputFile;

public:
    // �������� �����
    FileReader(const string& fileName) 
    {
        inputFile.open(fileName);
        if (!inputFile.is_open()) 
        {
            cerr << "�� ������� ������� ���� ��� ������: " << fileName << endl;
        }
    }

    // ����� ��� ��������, ������ �� ����
    bool isOpen() const 
    {
        return inputFile.is_open();
    }

    // ����� ��� ������ ������ � IP � MAC-��������
    bool readSTR(string& ip, string& mac) 
    {
        // ���������, ���� ����� ������� ������ ������
        if (inputFile >> ip >> mac) 
        {
            return true;  
        }
        else 
        {
            return false; 
        }
    }


    // �������� �����
    void close() 
    {
        if (inputFile.is_open()) 
        {
            inputFile.close();
        }
    }
};

// ����� ��� ������ ������ � ����
class FileWriter 
{
    ofstream outputFile;

public:
    // �������� ����� ��� ������
    FileWriter(const string& fileName) 
    {
        outputFile.open(fileName);
        if (!outputFile.is_open()) 
            cerr << "�� ������� ������� ���� ��� ������: " << fileName <<endl;
    }

    // ����� ��� ��������, ������ �� ����
    bool isOpen() const 
    {
        return outputFile.is_open();
    }

    // ������ ������ � ����
    void writeSTR(const string& str) 
    {
        outputFile << str << endl;
    }

    // �������� �����
    void close() {
        if (outputFile.is_open()) 
        {
            outputFile.close();
        }
    }
};

// ����� ��� ��������� ������
class DhcpdFormatter 
{
public:
    // ����� ��� �������������� MAC-������ (������ "-" �� ":")
    string formatMac(const string& mac) 
    {
        string formattedMac = mac;
        for (char& ch : formattedMac) 
        {
            if (ch == '-') 
                ch = ':';
        }
        return formattedMac;
    }

    // ����� ��� ��������� ����� ������ ��� ����� dhcpd
    string generateDhcpdEntry(int hostNumber, const string& ip, const string& mac) 
    {
        string formattedMac = formatMac(mac);
        string result = "host-" + to_string(hostNumber) + "\n{\n";
        result += "\thardware ethernet\t" + formattedMac + ";\n";
        result += "\tfixed-address\t\t" + ip + ";\n";
        result += "}\n";
        return result;
    }
};

// ����� ��� ���������� ���� ���������
class DhcpdProcessor 
{
private:
    FileReader reader;
    FileWriter writer;
    DhcpdFormatter formatter;

public:
    // �����������, ���������������� �������� � ��������
    DhcpdProcessor(const string& inputFileName, const string& outputFileName)
        : reader(inputFileName), writer(outputFileName) {}

    // ����� ��� ���������� ���� ��������� ������
    void process() 
    {
        if (!reader.isOpen() || !writer.isOpen()) 
        {
            return;
        }

        string ip, mac;
        int hostCount = 1;

        while (reader.readSTR(ip, mac)) 
        {
            string Temp = formatter.generateDhcpdEntry(hostCount, ip, mac);
            writer.writeSTR(Temp);
            hostCount++;
        }

        reader.close();
        writer.close();
    }
};

struct F
{
    int x, y;
};
struct F1
{
    int x, y, z;
};

int main() {
    DhcpdProcessor dhcp("201 RAW.txt", "201.dhcpd.txt");
    dhcp.process();

    system("notepad 201.dhcpd.txt");
    
    /*F* ptr_f = new F{ 1,2 };
    F1* ptr_f1 = (F1*)(ptr_f);
    F1* ptr_f2 = static_cast<F1*>(ptr_f);
    delete ptr_f;*/
    return 0;
}

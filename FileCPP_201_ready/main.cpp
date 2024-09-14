#include<iostream>
#include<fstream>
#include<string>
#include <sstream>//https://cplusplus.com/reference/sstream/istringstream/istringstream/
#include<vector>
using namespace std;

class FileInterface
{
protected:
	string FileName;
	virtual bool openFile() = 0;
	virtual void closeFile() = 0;
	virtual void Do() = 0;
public:
	FileInterface(const string& file) : FileName(file) {}//конструктор

	void process()
	{
		if (openFile())
		{
			Do();
			closeFile();
		}
		else
			cerr<<"Ошибка при открытии файла: " << FileName <<endl;
	}

	virtual ~FileInterface() {}
};
class Reader :public FileInterface
{
	ifstream inputFile;
	vector<string>vstr;
public:
	Reader(const string& inputFileName) : FileInterface(inputFileName) {}
	vector<string>GetStr()const
	{
		return vstr;
	}
protected:
	bool openFile() override//открытие
	{
		inputFile.open(FileName);
		return inputFile.is_open();
	}
	void closeFile() override//закрытие
	{
		inputFile.close();
	}
	void Do() override
	{
		string Temp;
		while (getline(inputFile, Temp))
		{
			if (!Temp.empty())
				vstr.push_back(Temp);
		}
	}
};

class Writer :public FileInterface
{
	ofstream outputFile;
	vector<string> vstr;
public:
	Writer(const string& outputFileName, const vector<string>& vstr) : FileInterface(outputFileName), vstr(vstr) {}
protected:
	bool openFile() override
	{
		outputFile.open(FileName);
		return outputFile.is_open();
	}
	void closeFile() override
	{
		outputFile.close();
	}
	void Do() override
	{
		for (const auto& item : vstr)
		{
			//https://cplusplus.com/reference/sstream/istringstream/istringstream/
			string ip, mac;
			istringstream iss(item);
			if (iss >> ip >> mac)
			{
				outputFile << mac;
				outputFile << string(Space(item), ' ');
				outputFile << ip << endl;
			}
		}
	}
	int Space(const string& Temp)
	{
		int count = 0;
		for (char item : Temp)
			if (item == ' ')count++;
		return count;
	}
};



int main()
{
	setlocale(LC_ALL, "");

	Reader reader("201 RAW.txt");
	reader.process();  // Чтение данных
	vector<string> Buffer = reader.GetStr();
	for (auto item : Buffer)
		cout << item << endl;
	Writer writer("201 ready.txt", Buffer);
	writer.process();
	system("notepad 201 ready.txt");
	return 0;
}
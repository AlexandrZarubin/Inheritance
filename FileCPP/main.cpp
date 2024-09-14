//stdin
//stdout
#include<iostream>
#include<fstream>
using std::cin;
using std::cout;
using std::endl;

//#define WRITE_TO_FILE
#define READ_FROM_FILE

void main()
{
	setlocale(LC_ALL, "");

#ifdef WRITE_TO_FILE
	cout << "Hello World" << endl;
	std::ofstream fout;		//1) ������� �����
	fout.open("File.txt", std::ios_base::app);	//2) ��������� �����
	fout << "Hello World" << endl;	//3) ����� � �����
	fout.close();			//4) ��������� �����

	system("notepad File.txt");
#endif // WRITE_TO_FILE

	cout << strlen(R"(<meta name="scope" content="Windows, Desktop" /><meta name="github_feedback_content_git_url" content="https://github.com/MicrosoftDocs/sdk-api/blob/docs/sdk-api-src/content/fileapi/nf-fileapi-readfile.md" /><link href="https://learn.microsoft.com/en-us/windows/win32/api/fileapi/nf-fileapi-readfile" rel="canonical"><title>ReadFile function (fileapi.h) - Win32 apps | Microsoft Learn</title><link rel="stylesheet" href="/static/assets/0.4.028055824/styles/site-ltr.css">)") << endl;;
	system("PAUSE");
	std::ifstream fin("File.txt");	//1) �������� ������ ����� ����������� � ��������� ������
	if (fin.is_open())
	{
		//TODO: read from file
		while (!fin.eof())
		{
			const int SIZE = 1536;
			char sz_buffer[SIZE]{};
			//fin >> sz_buffer;	//��� 'fin', ��� �� ��� � ��� 'cin' ������ �������� �������� ������������,
								//� ��� ����, ����� ��������� ������ � ���������, ������ 'cin' ������������ 'cin.geline()'.
			fin.getline(sz_buffer, SIZE);
			cout << sz_buffer << endl;
		}
		fin.close();
	}
	else
	{
		std::cerr << "Error: file not found" << endl;
	}
}
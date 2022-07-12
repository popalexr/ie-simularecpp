#include <fstream>
std::ifstream fin("in.txt");
std::ofstream fout("rez.txt");
std::ofstream afis("afisari.txt");
#include <iostream>

using namespace std;

int main()
{
	int a, b;
	fin >> a >> b;afis<<"a:"<<a<<endl; afis<<"b:"<<b<<endl; 
	while (a != b)
	{
		if (a > b) {
			a -= b;afis<<"a:"<<a<<endl;
		}
		else {
			b -= a;afis<<"b:"<<b<<endl;
		}
	}
	fout << a; afis<<"consola:"<< a<<endl;
	return 0;
}


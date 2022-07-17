#include <fstream>
std::ifstream fin("in.txt");
std::ofstream fout("rez.txt");
std::ofstream afis("afisari.txt");
#include <iostream>

using namespace std;

int main()
{
	int n, k = 0;afis<<"k:"<<k<<endl;
	fin >> n;afis<<"n:"<<n<<endl; 
	do {
		int uc = n % 10;afis<<"uc:"<<uc<<endl;
		if (uc == 0) {afis<<"expresie((uc==0)):"<<(bool)(uc==0)<<endl;
			k++;afis<<"k:"<<k<<endl;
		}
		n /= 10;afis<<"n:"<<n<<endl;
	} while (n);
	fout << k; afis<<"consola:"<< k<<endl;
	return 0;
}


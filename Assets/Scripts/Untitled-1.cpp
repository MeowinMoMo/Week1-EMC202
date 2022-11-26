#include <iostream>
using namespace std;

int factorial (int n){
    if(n == 0){
        return 1;
    }
    else{
        return n * factorial(n-1);
    }
}

int main(){
    cout << "Hello User~! \n";

    int user_input; 
    scanf("%i", &user_input);
}
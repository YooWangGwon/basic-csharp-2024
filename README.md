# C# 기본학습
부경대학교 2024 IoT 개발자 과정 C# 리포지토리

## 1일차(24.04.11)
- C# 소개
	- MS에서 개발한 차세대 프로그래밍 언어
	- 2000년 최초 발표, 앤더스 하일버그(파스칼, 델파이 개발자)
	- 1995년 Java가 발표되면서 이를 경쟁하기 위해 개발
	- 객체지향 언어, C/C++과 Java를 참조해서 개발
	- OS 플랫폼 독립적, 메모리 관리 쉬움
	- 다양한 분야에서 사용 중
	- 2024년 12버전
	
- .NET Framework(CLR)
	- Window OS에 종속적
	- OS 독립적인 새롱누 틀을 제작하기 시작(2022년~) -> .NET 5.0
	- 2024년 현재 .NET 8.0
	- C/C++은 gcc 컴파일러, Java는 JDK, C#은 .NET 5.0 이상이 필요
	- 이제는 신규 개발 시 .NET Framework는 사용하지 말것! 
	
- Hello, C#
	- Visual Studio 시작
	- 프로젝트 : 프로그램을 만들 수 있는 하나의 최소단위
	- 솔루션 : 프로젝트의 묶음
	- .csproj 파일 :  시스템 어셈블리에 대한 참조와 함께 프로젝트에 포함된 파일 목록이 포함된 C# 프로젝트 파일
	- obj 폴더의 내용 : 컴퓨터에서 컴파일할 때 만들어지는 중간파일들(GitHub에 올릴 필요 X)
	- 솔루션 구성
		- Debug : 개발할 때 사용 -> 디버깅 기능이 포함되기 때문에 Release보다 느림
		- Release : 사용자들에게 배포할 때 사용
	```cs
	namespace hello_world // 프로그램  소스의 가장 큰 단위 : namespace -> 파이썬의 모듈, 라이브러리 역할
	{
		internal class Program  // 접근제한자 class 파일명/internal은 class 구조체의 private과 유사함/파일명과 클래스명이 달라도 됨
		{
			static void Main(string[] args) // 메인함수는 프로그램이 실행될 때 처음부터 끝까지 실행되야하기 때문에 static(정적변수) 선언, 리턴값이 void라 없는것과 마찬가지
			{                               // C#에서는 모든 Method(함수)를 쓸 때 대문자로 시작해야함
				// System 네임스페이스 >> Console 클래스에 잇는 정적메서드 WriteLine()
				Console.WriteLine("Hello, World!"); // C++의 cout과 유사
			}
		}
	}
	```

- 변수와 상수
	- C++과 동일
	- 값 형식 : 메모리에 값(정수, 실수)을 담는 데이터 형식 -> 스택에 할당(자동으로 제거됨)
	- 참조 형식 : 메모리에 다른 변수의 주소(클래스, 문자열, 리스트, 배열)를 담는 데이터 형식 -> 힙에 할당(가비지 콜렉터에 의해 제거됨)
	- 모든 C#의 객체는 Object를 조상으로
	- 박싱(Boxing), 언박싱(Unboxing)
	```cs
	int a = 20;		// 스택에 할당
	object b = a;	// 박싱(값 형식을 Object 형식(박스)에 담는다) -> 힙에 올리는 것
	
	int c = (int) b; // 언박싱(Object를 각 타입으로 변환)
	```

	- 상수는 const 키워드 사용
	- 열거형식(Enumerated Type)
		- 하나의 잉름 아래 묶인 상수들의 집합
		- enum키워드 사용

	- var 키워드
		- 컴파일러가 자동으로 타입을 지정해주는 변수(var a = 3; -> a는 int 형식, var b = "Hello"; -> b는 string 형식)
		- 지역변수에만 사용 가능(전역변수 X)

- 연산자
	- C++과 동일
	- ++, --가 파이썬에 없다는 것
	- and, or가 C++, C#에서는 && || 라는 것

- 흐름 제어
	- C++과 동일!
	- if, switch, while, do~while, for, break, continue, goto 모두 동일
	- C#에는 foreach가 존재 - python의 for item in []과 동일
	```cs
	int[] arr = { 1, 2, 3, 4, 5};

	foreach (var item in arr)
	{
		Console.WriteLine($"현재 수 : {item}");
	}
	```

- 메서드(Method)
	- 함수와 동일. 구조적 프로그래밍에서 함수면, 객체지향에서는 메서드로 부른다(파이썬만 예외)
	- 매개변수 참조형식 -> C++에서 Pointer로 값을 사용할 때와 동일한 기능
	```cs
	public static void RefSwap(ref int a, ref int b)
	{
		int temp = b;
		b = a;
		a = temp;
	}
	// 사용시에도 ref 키워드 사용
	RefSwap(ref x, ref y);
	```

	- 매개변수 출력형식 -> 매개변수를 리턴값으로 사용하도록 대체해주는 방법(과도기적인 방법)
	```cs
	public static void Divide(int a, int b, out int quotient, out int remainder)   // 값을 두개 이상 리턴하고 싶을 때 out 사용
	{	// ...
	```

	- 메서드 오버로딩 -> 여러 타입으로 같은 처리를 하는 메서드를 여러개 만들 때
	```cs
	public static int Plus(int a, int b)
	{	// ... 
	public static float Plus(float a, float b)
	{	// ...
	```

	- 매개변수 가변길이 -> 매개변수 개수를 동적으로 처리할 때(params 키워드와 배열을 이용해 선언)
	```cs
	public static int Sum(params int[] argv)
	{	// ...
	```
	- 명명된 매개변수 -> 매개변수 사용순서를 변경가능
	```cs
	public static void PrintProfile(string name, string phone)
	{	// ...
	```

	- 기본값 매개변수 -> 매개변수 값 미할당시 기본값으로 지정
	```cs
	public static void DefaultMethod(int a = 1, int b = 0)
	{	// ...
	DefaultMethod(10, 8); 	// a = 10, b = 8
	DefaultMethod(6);		// a = 6, b = 0
	DefaultMethod();		// a = 1, b = 0
	```

- 클래스
	- C++의 클래스, 객체와 유사(문법이 다소 상이함)
	- 생성자는 new를 사용하여 객체 생성
	- C#에서는 종료자(파괴자, cpp의 소멸자)를 거의 사용하지 않음
	- this키워드 -> C++에서는 this->, C#에서는 this. (파이썬의 self와 동일)
	- 생성자 오버로딩 -> 파라미터 개수에 따라서 사용가능, 기본적인 메서드 오버로딩과 기능은 동일
	- 접근한정자(Access Modifier)
		- public : 모든 곳에서 접근 가능
		- private : 외부에서 접근 불가(default)
		- protected : 외부에서 접근 불가 but 파생(상속) 클래스에서는 사용가능
		- internal : 같은 어셈블리(네임스페이스) 내에서는 public과 동일. 다른 어셈블리에서는 사용가능
		- protected internal, private protected : 난이도 있는 한정자(고급)

	- C#에는 C++과 같은 다중상속 없음. C++ 다중상속으로 생기는 문제점을 해결하기 위해서 다중상속을 아ㅖ 없앰
		- 다중상속이 필요함을 해결 -> 인터페이스
		```cs
		class BaseClass{
			// 부모클래스
		};
		class DerivedClass : BaseClass{
			// 파생(자식 클래스)
		};
		```

- 구조체
	- 객체지향이 없었을 때 좀더 객체지향적인 프로그래밍을 위해서 만들어진 부분(C에서)
	- class 이후로 사용빈도가 완전히 줄어든 구조
	- 구조체 스택(값 형식), 클래스 힙(참조형식)
	- C#에서는 구조체 쓰지 않아도 됨

- 튜플(C# 7.0 이후 반영)
	- 한꺼번에 여러개의 데이터를 리턴하거나 전달할 때 유용
	- 값 할당 후 변경 불가	

- 인터페이스
	- 클래스 : 객체의 청사진 / 인터페이스 : 클래스의 청사진
	- 인터페이스는 클래스가 어떠한 메서드를 가져야 하는지를 약속하는 것
	- 다중 상속의 문제를 단일 상속으로도 해결하게 만든 주체
	- 인터페이스는 명명할 때 제일 앞에 I를 적음.
	- 인터페이스에서는 (기본적으로)메서드 구현을 작성하지 않음
	- 인터페이스는 약속!
	- 클래스는 상속한다 vs 인터페이스는 구현한다
	- 클래스는 상속시 별다른 문제없음 vs 인터페이스는 구현을 하면 약속을 지키지 않으면 오류표시
	- 인터페이스에서 약속한 메서드를 구현안하면 빌드 안됨!
   
   	![인터페이스_설명](https://raw.githubusercontent.com/YooWangGwon/basic-csharp-2024/main/images/cs001.png)

- 추상클래스(Abstract Class)
	- Virtual 매서드하고도 유사
	- 추상클래스를 단순화 시키면 인터페이스

- 프로퍼티
	- 클래스의 멤버변수의 변형 -> 멤버변수를 조금 더 구조화 시킨 것
	- public 필드를 다루듯 내부 필드에 접근하게 해주는 멤버
	- 멤버변수의 접근제한자를 public으로 했을 때의 여러 객체지향적 문제점(코드 오염 등)을 해결하기 위해서
	- GET 접근자/SET 접근자
	- SET은 값 할당시에 잘못된 데이터가 들어가지 않도록 제약을 걸어줘야함
	- Java에서는 Getter메서드/Setter메서드로 사용

## 2일차(24.04.12)
- 컬렉션(배열, 리스트, 인덱서)
- 일반화(Generic) 프로그래밍
- 예외처리
- 대리자와 이벤트
- 람다식
- 애트리뷰트
- dynamic 형식
- Winform(파일, 스레드)
- 가비지 컬렉션
- 네트워크 프로그래밍

- WPF
- 예제 프로젝트

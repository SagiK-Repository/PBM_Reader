문서정보 : 2023.06.12. 작성, 작성자 [@SAgiKPJH](https://github.com/SAgiKPJH)

<br>

# PBM_Reader
PowerShell 활용한 WPF MVVM PBM Reader

### 목적 1
- 다음 조건을 만족하는 프로젝트를 제작합니다.  
1. WPF MVVM 구조로 제작을 합니다.
2. Devexpress를 활용합니다.
3. PowerShell의 명령어 입력 결과를 나타냅니다.
4. PBM 명령어 결과를 나타냅니다.
5. 입력 명령어에 필요한 정보를 쉽게 입력할 수 있도록 합니다.
6. 결과에 대한 표를 보여줍니다.
7. 표에 색이 포함되어 나타납니다.
8. 원하는 시간별로 주기적으로 업데이트 합니다.
9. TestCode를 작성합니다.
10. 위 모든 과정을 문서로 제작합니다.
* 과연 위의 모든 과정을 작성하는데 있어서 몇 시간이 걸릴까?

### 목적 2 (2023.06.18.~)
- 다음 조건을 만족하는 프로젝트를 제작합니다.
1. WPF MVVM 구조로 제작을 합니다.
2. Devexpress를 활용합니다.
3. IP와 PORT를 입력받아, petabridge의 cluster show 명령어를 C#으로 받습니다.
4. 나타난 상태 정보를 획득하여 text에 출력합니다.
5. 입력 명령어에 필요한 정보를 쉽게 입력할 수 있도록 합니다.
6. 결과에 대한 표를 보여줍니다.
7. 표에 색이 포함되어 나타납니다.
8. 원하는 시간별로 주기적으로 업데이트 합니다.
9. TestCode를 작성합니다.
10. C# 코드를 구성해줘.
11. 위 모든 과정을 문서로 제작합니다.
* 과연 위의 모든 과정을 작성하는데 있어서 몇 시간이 걸릴까?


### 목표
- [x] 1. 프로젝트 구성
- [x] 2. 기능 구성
- [x] 3. 기능 설계
- [ ] 4. 기능 구현 

### 제작자
[@SAgiKPJH](https://github.com/SAgiKPJH)

<br>
---
<br>

# 1. 프로젝트 구성

- WPF 프로젝트 (.NET Framework) (v4.7)
  - ReferenceList.txt : 참조 리스트 기록
  - Common : 공통되는 폴더
    - Static : 공유 폴더
  - Model
  - ViewModel
  - View
- 단위 테스트 프로젝트 (.NET Framework) (v4.7)
  - ReferenceList.txt : 참조 리스트 기록
  - 프로젝트와 동일한 폴더 및 파일 구조

<br>

# 2. 기능 구성

### 요구사항 정리
- Powershell 명령어 입력
- PowerShell 입력 결과 출력
- 특정한 명령어
- 주기적인 명령 결과 출력
- 표를 통한 시각화
  - 결과 데이터 분리
- 편리 기능 추가
  - 이전에 입력한 내용 바로 붙여넣기 가능
  - 이전에 셋팅한 Layout 저장 기능
  - 빠르게 단축키로 설정 가능 기능

<br>

### 기능 정리
1. Powershell 특정 명령어 입력 기능 (코드)
2. Powershell 특정 명령어 입력 기능 (UI)
3. Powershell 명령 결과 반환 기능 (코드)
4. Powershell 명령 결과 반환 기능 (UI)
5. 주기적인 명령어 반환 기능 (코드)
6. 주기적인 명령어 반환 기능 (UI)
7. 반환 된 명령어 분석 기능 (코드)
8. 명령어 표를 통한 출력 기능 (UI)
9. 편리기능

<br>

### 기능 구체화
1. Powershell와의 연동 가능 기능
2. 명령어 분석 기능
3. 표 출력 기능
4. 편리 기능

<br>

# 3. 기능 설계
### 각 기능별 이름 설계
- Powershell와의 연동 가능 기능 : PowerShellHandeling.cs
  - Powershell 명령어 입력 기능 : EnterCommand(string command);
  - PowerShell 명령어 반환 기능 : List<string> EnterCommand(string command);
  - PowerShell 명령어 주기적 반환 기능 : List<string> EnterCommand(string command, TimeSpan repeatTime);
- 명령어 분석 기능 : TextAnalysis.cs
  - 명령어 분리 기능 : AnalysisReturnString(string returnString);
  - 명령어들 분리 기능 : List<string> AnalysisReturnListString(List<sting> returnListSting);






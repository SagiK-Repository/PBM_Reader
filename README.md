문서정보 : 2023.06.12.~08.10. 작성, 작성자 [@SAgiKPJH](https://github.com/SAgiKPJH)

<br>

# PBM_Reader
PowerShell 활용한 WPF MVVM PBM Reader

<img src="https://github.com/SagiK-Repository/PBM_Reader/assets/66783849/f80e3313-dcd1-4a66-9226-4a4156ffdb21"/>

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






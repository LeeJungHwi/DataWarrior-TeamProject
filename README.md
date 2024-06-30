⭐️ 전북대학교 게임및혼합현실 팀 프로젝트에서 기여했던 것을 구분하기 쉽게 분리한 레포 입니다.  
✨ [팀 프로젝트 레포지토리](https://github.com/LeeJungHwi/DataWarrior)

<br>

# 주요 기능  
⚡ 스킬 시스템
- 스킬 데이터 : Scriptable Object
- ![스킬 데이터](https://github.com/LeeJungHwi/DataWarrior_./assets/101587101/dc0a2e95-4e38-48fa-acb3-7d69af8a724f)

<br>

- 스킬 UML
  - Ability Base : Scriptable Object 상속 ⇒ 모든 스킬 공통 멤버 정의
  - AsyncAbility Base : Ability Base 상속 ⇒ 비동기 스킬 공통 멤버 정의
  - SyncAbility Base : Ability Base 상속 ⇒ 동기 스킬 공통 멤버 정의
  - Ability Implement : 기반 스킬 상속 ⇒ 각 스킬 구체화
  - Ability FSM : Ability Base 참조 ⇒ 각 FSM의 스킬 데이터가 갖는 스킬 상태 관리
  - Ability Pool : 스킬 시전 또는 종료 시 스킬 오브젝트와 사운드 풀링
- ![스킬 다이어그램 drawio - 복사본 drawio](https://github.com/LeeJungHwi/DataWarrior_./assets/101587101/dbd18a8a-8957-462e-8c2f-f26471267e5e)

<br>

- 스킬 FSM
- ![스킬시스템 UML drawio](https://github.com/LeeJungHwi/DataWarrior_./assets/101587101/e0579ec3-fc5b-430c-8fe1-3462ca20c3ec) ![스킬 FSM 인스펙터](https://github.com/LeeJungHwi/DataWarrior_./assets/101587101/ab14428c-3663-4847-ba0b-7badf90f1da1)

<br>

- 스킬 충돌 : Particle Collision

<br>

⚡ 무기 교체 시스템
- Ability Change : 무기 교체 관리를 위해 WeaponType형 프로퍼티 유지 ⇒ 셋될 때 특정 로직 수행
  - Ability Image Change : 스킬 이미지 교체
  - Ability Info Change : 스킬 툴팁 정보 교체
  - Ability Unlock : 스킬 해제 상태 체크
  - Selected Focus : 선택된 무기 강조
  - Weapon Unlock : 무기 해제 상태 체크
```csharp
public class AbilityChange : MonoBehaviour
{
    private WeaponType weaponT;
    public WeaponType WeaponT
    {
        get { return weaponT; }
        set
        {
            abilityImageChange.SelectedWeaponAbilityImage(value);
            selectedFocus.SelectedWeaponFocus(weaponT, value);
            weaponT = value;
            SkillChange();
            WeaponChangeCoolInit();
            abilityInfoChange.SetAbilityToolTipInfo(value);
            abilityUnlock.AbilityUnlockStateCheck(value);
            weaponChangeSound.SetActive(true);
        }
    }

    ...
}
```

SurvivorLike_Unity (공부용)

Unity 2D 공부
##Input System 패키지 설치 전
- 플레이어 이동 구현 (Input System 패키지 전)
- 입력 : Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")
- 이동 방식 Rigidbody2D.MovePosition()

##Input System 패키지 설치 후
-Input System 패키지로 인한 입력 이벤트 콜백 함수를 통해 OnMove() 사용.
- OnMove()로 입력을 받으면, Input Action에서 normalize 옵션을 켜서 값이 이미 normalize 상태로 전달. 따라서 Fixed Update()에서 다시 normalize를 적용할 필요x


# **Amazing Array**

+ ### 다양한 기능을 제공하는 커스텀 Array Class.
+ ### 값, 참조 형식 대응 가능
+ ### [] 키워드 접근 가능
+ ### IEnumerable 인터페이스 사용으로 foreach 사용 가능

---

#### 1. 복제 함수 
> CopyFullArray(T[] array) : 받은 배열을 AArray 에 복사
> static CopyFullArray(T[] from, T[] to) : from 배열을 to 배열로 복사

#### 2. 추가 함수 
> Add(T item) : 요소를 마지막에 추가
> AddUnique(T item) : 고유한 요소라면 추가
> InsertAtIndex(T item, int index) : 해당 위치에 요소 삽입
> AddRange(T[] array, int index) : 해당 위치에 배열 삽입
> AddFirst(T item) : 요소를 첫번째에 추가

#### 3. 삭제 함수 
> RemoveElement(T targetElement) : 요소를 삭제
> RemoveAtIndex(int index) : 인덱스의 요소를 삭제
> RemoveFirst(), RemoveEnd() : 맨 앞,뒤의 요소를 삭제

#### 4. 정렬 함수 
> SortASC(Func<T, K> f) : 오름차순 정렬
> SortDESC(func<T, K> f) : 내림차순 정렬

#### 5. 검색 함수 
> FindIndex(T item) : 요소의 인덱스를 반환
> FindFirst(Func<T, bool> f) : 조건에 맞는 첫 번째 요소를 반환
> FindAll(Func<T, bool> f) : 조건에 맞는 모든 요소를 반환

#### 6. 섞기 함수 
> Shuffle(int count) : 요소를 지정한 횟수만큼 섞기

#### 7. 반전 함수 
> Reverse() : 배열 반전

#### 8. 뽑기 함수 
> PickRandom() : 랜덤한 요소를 하나 반환

#### 9. 이동 함수 
> PushRight(), PushLeft() : 배열을 오른쪽, 왼쪽으로 하나의 인덱스만큼 이동

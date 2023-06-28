class Detail {
	namespace = 'detail';

	beforeEnter = data => {
		console.log(data, 'on detail page');
	};
}

export default new Detail();
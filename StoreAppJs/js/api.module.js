const baseUrl = 'https://localhost:7217';

export const getProds = async () => {
    try {
        const res = await fetch(`${baseUrl}/products`);
        const ret = await res.json();
        return ret;
    } catch (error) {
        console.log(error);
    }
}
export const getProd = async (id) => {
    try {
        const res = await fetch(`${baseUrl}/products/${id}`);
        const ret = await res.json();
        return ret;
    } catch (error) {
        console.log(error);
    }
}
export const upsert = async (prod) => {
    try {
        const req = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(prod)
        };

        const res = await fetch(`${baseUrl}/products`, req);
        const ret = await res.json();
        return ret;
    } catch (error) {
        console.log(error);
        return null;
    }
}
export const remove = async (id) => {
}

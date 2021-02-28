import axios from "axios";

const baseUrl = "https://localhost:44306/api/"



export default {

    dCandidate(url = baseUrl + 'candidate/') {
        return {
            fetchAll: () => axios.get(url),
            fetchById: id => axios.get(url + id),
            create: newRecord => axios.post(url, newRecord),
            update: (id, updateRecord) => axios.put(url + id, updateRecord),
            delete: id => axios.delete(url + id)
        }
    }
}
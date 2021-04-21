var titles = [
    {
        label: "CEO",
        value: false
    },
    {
        label: "Salesperson",
        value: true
    },
    {
        label: "Marketing Assistant",
        value: true
    },
    {
        label: "Sales Manager",
        value: true
    },
    {
        label: "Marketing Manager",
        value: false
    }
];

var extractCheckedTitles = function(titles)
{
    // Filters out the titles with the value of false.
    var filteredTitles = titles.filter((item) => {
        return item.value == true
    })

    // New array to hold only the labels from filteredTitles.
    var sortedString = []

    // For loop to add the labels from filteredTitles to the sortedString array
    for (i = 0; i < filteredTitles.length; i++) {
        sortedString.push(filteredTitles[i].label)
    }

    // Sorts the label alphabetically
    sortedString.sort()

    // Returns the labels sorted alphabetically.
    return sortedString.join(", ")
};

extractCheckedTitles(titles);